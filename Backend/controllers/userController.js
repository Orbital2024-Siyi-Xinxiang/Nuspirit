const pool = require('../config/db');

exports.updateLocation = async (req, res) => {
    const { userId, latitude, longitude } = req.body;
    try {
        const query = 'UPDATE users SET current_location = point($2, $3) WHERE id = $1';
        const values = [userId, latitude, longitude];
        await pool.query(query, values);
        res.status(200).send('Location updated successfully');
    } catch (error) {
        res.status(500).send(error.message);
    }
};
