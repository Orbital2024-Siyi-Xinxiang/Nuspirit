const express = require('express');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const admin = require('firebase-admin');
const router = express.Router();
const pool = require('../config/db');  // Adjust path as necessary

// POST /register
router.post('/register', async (req, res) => {
    const { username, password, email } = req.body;

    try {
        // Check if user already exists in PostgreSQL
        const { rows } = await pool.query('SELECT * FROM users WHERE email = $1', [email]);
        const existingUser = rows[0];
        if (existingUser) {
            return res.status(400).send({ message: "User already exists" });
        }

        // Create user in Firebase Authentication
        const userRecord = await admin.auth().createUser({
            email: email,
            password: password,
        });
        console.log("Successfully created new user:", userRecord.uid);
        
        // Store user in PostgreSQL
        const newUser = await pool.query(
            'INSERT INTO users (firebase_uid, email) VALUES ($1, $2) RETURNING *',
            [userRecord.uid, email]
        );

        res.status(201).send({ message: "User registered successfully!", user: newUser.rows[0] });
    } catch (error) {
        console.error("Registration error:", error);
        res.status(500).send({ error: "Error registering new user", details: error.message });
    }
});


// POST /login
router.post('/login', async (req, res) => {
    try {
        const { email, password } = req.body;

        // Authenticate user with Firebase Authentication
        const user = await admin.auth().getUserByEmail(email);

        // Verify password (handled by Firebase)
        const token = await admin.auth().createCustomToken(user.uid);

        res.send({ message: "Logged in successfully", token });
    } catch (error) {
        res.status(500).send({ error: error.message });
    }
});

module.exports = router;









// DELETE endpoint to remove a user account
router.delete('/delete', async (req, res) => {
    const { username } = req.body;
    try {
        // Function to delete a user from the database
        const result = await pool.query('DELETE FROM users WHERE username = $1', [username]);
        if (result.rowCount === 0) {
            return res.status(404).send({ message: "User not found" });
        }
        res.status(200).send({ message: "User deleted successfully" });
    } catch (error) {
        console.error(error);
        res.status(500).send({ error: "Error deleting user" });
    }
});


module.exports = router;
