const express = require('express');
const bodyParser = require('body-parser');
const { Pool } = require('pg');

const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { exec } = require('child_process');

require('dotenv').config();

// const admin = require('firebase-admin');
// const serviceAccount = require('./config/firebaseAccountKey.json'); // Download this from Firebase Console
// admin.initializeApp({
//     credential: admin.credential.cert(serviceAccount)
// });


const sqlFiles = [
    '../Database/orbital.sql',
    '../Database/market.sql',
    '../Database/contact.sql',
];

const app = express();
app.use(bodyParser.json());

// PostgreSQL pool setup
const pool = new Pool({
    connectionString: `postgresql://${process.env.DB_USER}:${process.env.DB_PASS}@localhost:5432/${process.env.DB_NAME}`
});

// test database connection
pool.query('SELECT NOW()', (err, res) => {
    if (err) {
        console.log('Database connection unsuccessful', err);
    } else {
        console.log('Database connection successful', res.rows[0]);
    }
});

// // import dumped database
pool.connect((err) => {
    if (err) {
        console.error('Connection error', err.stack);
    } else {
        console.log('Connected to the database');

        sqlFiles.forEach((file) => {
            // Import the dump file
            exec(`psql -U emma -d orbital_db -f ${file}`, (err, stdout, stderr) => {
                if (err) {
                    console.error(`Error importing ${file}`, err);
                } else {
                    console.log(`${file} imported successfully`);
                }
            });
        });
    }
});






// Example route using async/await to query PostgreSQL
app.get('/data', async(req, res) => {
    try {
        const result = await pool.query('SELECT * FROM users');
        res.json(result.rows);
    } catch (err) {
        console.error(err);
        res.status(500).send('Server Error');
    }
});



// Import routes
const authRoutes = require('./routes/authRoutes.js');
app.use('/api/auth', authRoutes);










// furniture markets
// Fetch market assets
app.get('/market', async(req, res) => {
    try {
        const result = await pool.query('SELECT * FROM market');
        res.json(result.rows);
    } catch (err) {
        res.status(500).send(err.message);
    }
});


// Purchase an asset
app.post('/purchase', async(req, res) => {
    const { userId, assetId } = req.body;
    const client = await pool.connect();

    try {
        await client.query('BEGIN');

        // Get user and asset details
        const userResult = await client.query('SELECT * FROM users WHERE id = $1', [userId]);
        const assetResult = await client.query('SELECT * FROM market WHERE id = $1', [assetId]);

        if (userResult.rows.length === 0 || assetResult.rows.length === 0) {
            throw new Error('User or asset not found');
        }

        const user = userResult.rows[0];
        const asset = assetResult.rows[0];

        if (user.balance < asset.price) {
            throw new Error('Insufficient balance');
        }

        if (asset.quantity <= 0) {
            throw new Error('Asset out of stock');
        }

        // Update user balance and assets
        const newBalance = user.balance - asset.price;
        const newAssets = [...user.assets, { id: asset.id, name: asset.name, icon: asset.icon }];
        await client.query('UPDATE users SET balance = $1, assets = $2 WHERE id = $3', [newBalance, JSON.stringify(newAssets), userId]);

        // Update asset quantity
        const newQuantity = asset.quantity - 1;
        await client.query('UPDATE market SET quantity = $1 WHERE id = $2', [newQuantity, assetId]);

        await client.query('COMMIT');
        res.send({ message: 'Purchase successful' });
    } catch (err) {
        await client.query('ROLLBACK');
        res.status(500).send(err.message);
    } finally {
        client.release();
    }
});
















// Start the server
const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`);
});