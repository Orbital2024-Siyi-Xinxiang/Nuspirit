const express = require('express');
const bodyParser = require('body-parser');
const { Pool } = require('pg');
require('dotenv').config();

const admin = require('firebase-admin');
const serviceAccount = require('./config/firebaseAccountKey.json'); // Download this from Firebase Console
admin.initializeApp({
    credential: admin.credential.cert(serviceAccount)
  });



const app = express();
app.use(bodyParser.json());

// PostgreSQL pool setup
const pool = new Pool({
    connectionString: `postgresql://${process.env.DB_USER}:${process.env.DB_PASS}@localhost:5432/${process.env.DB_NAME}`
});

pool.query('SELECT NOW()', (err, res) => {
    if(err) {
        console.log('Database connection unsuccessful', err);
    } else {
        console.log('Database connection successful', res.rows[0]);
    }
});

// Example route using async/await to query PostgreSQL
app.get('/data', async (req, res) => {
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








// Start the server
const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`);
});
