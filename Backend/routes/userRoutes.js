const express = require('express');
const router = express.Router();
const userController = require('../controllers/userController');

router.post('/update-location', userController.updateLocation);

module.exports = router;
