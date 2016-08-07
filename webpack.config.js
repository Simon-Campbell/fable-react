var path = require("path");
var webpack = require("webpack");

module.exports = {
    devtool: "source-map",
    entry: "./temp/FableReact.js",
    output: {
        path: path.join(__dirname, "public"),
        filename: "bundle.js"
    },
    module: {
        preLoaders: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loader: "source-map-loader"
            }
        ]
    }
};