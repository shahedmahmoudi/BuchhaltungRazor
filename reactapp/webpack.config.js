const webpack = require('webpack');
const path = require ('path');

const APP_DIR = path.resolve(__dirname,'');
const PUBLIC_DIR = path.resolve(__dirname,'public');


const config = {

    entry: APP_DIR + '/HelloWorld.js',

    output: {
        path: PUBLIC_DIR,
        filename: 'bundle.js'
    }

};

module.exports = config;