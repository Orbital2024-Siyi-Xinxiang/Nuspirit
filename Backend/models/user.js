const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    // other fields like username, email, etc.
    currentLocation: {
        latitude: Number,
        longitude: Number
    }
});

const UserModel = mongoose.model('User', userSchema);

module.exports = UserModel;
