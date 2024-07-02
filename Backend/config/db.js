const { Pool } = require('pg');
const pool = new Pool({
    user: 'emma', // replace with your PostgreSQL username
    host: 'localhost', // keep as is if you're running PostgreSQL locally
    database: 'orbital_db', // replace with your PostgreSQL database name
    password: 'emmaxu2005', // replace with your PostgreSQL password
    port: 5432, // keep as is if your PostgreSQL server is running on the default port
});

module.exports = pool;