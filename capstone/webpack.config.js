var path = require('path');
var fs = require('fs');
const { VueLoaderPlugin } = require('vue-loader')

var appBasePath = './Scripts/'; // where the source files located
var publicPath = '../bundle/'; // public path to modify asset urls. eg: '../bundle' => 'www.example.com/bundle/main.js'
var bundleExportPath = './wwwroot/bundle/'; // directory to export build files

var jsEntries = {}; // listing to compile

// We search for js files inside basePath folder and make those as entries
fs.readdirSync(appBasePath).forEach((name) => {

    // assumption: modules are located in separate directory and each module component is imported to index.js of particular module
    var indexFile = appBasePath + name + '/index.js'
    if (fs.existsSync(indexFile)) {
        jsEntries[name] = indexFile
    }
});

module.exports = {
    entry: jsEntries,
    output: {
        path: path.resolve(__dirname, bundleExportPath),
        publicPath: publicPath,
        filename: '[name].js'
    },
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            '@': path.join(__dirname, appBasePath)
        }
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: 'vue-loader',
            },
            {
                test: /\.scss$/,
                use: 'style-loader!css-loader!sass-loader'
            },
            {
                test: /\.css$/,
                use: 'style-loader!css-loader'
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
                use: 'file-loader'
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?\S*)?$/,
                use: 'file-loader'
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ],
    stats: {
        errorDetails: true
    },
    
    mode: "development",
}