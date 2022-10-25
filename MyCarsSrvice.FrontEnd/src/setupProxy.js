const createProxyMiddleware = require('http-proxy-middleware');

const context = [
    "/service"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7221',
        secure: false
    });

    app.use(appProxy);
};
