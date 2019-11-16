'use strict';

const HttpsProxyAgent = require('https-proxy-agent');

/*
 * API proxy configuration.
 * This allows you to proxy HTTP request like `http.get('/api/stuff')` to another server/port.
 * This is especially useful during app development to avoid CORS issues while running a local server.
 * For more details and options, see https://github.com/angular/angular-cli#proxy-to-backend
 */
const proxyConfig = [
  {
    context: '/api',
    pathRewrite: { '^/api': '' },
    target:'http://citybaseapi.azurewebsites.net/api',
   // target:'http://192.168.1.35:8080/api',
    //target: 'http://172.27.0.142:30020/api',
    //target: 'http://10.24.74.65:8080/api',
    //target: 'http://10.24.60.84:8080/api',
   // target: 'http://10.24.62.129:8080/api',
    changeOrigin: true,
    secure: false
  },
  // {
  //   context: '/api-hbb',
  //   // pathRewrite: { '^/cms': '' },
  //   target:'http://125.16.74.137:8082/home-broadband/',
  //  // target:'http://192.168.1.35:8080/api',
  //   //target: 'http://172.27.0.142:30020/api',
  //   //target: 'http://10.24.74.65:8080/api',
  //   //target: 'http://10.24.60.84:8080/api',
  //  // target: 'http://10.24.62.129:8080/api',
  //   changeOrigin: true,
  //   secure: false
  // }
];
/*
 * Configures a corporate proxy agent for the API proxy if needed.
 */
function setupForCorporateProxy(proxyConfig) {
  if (!Array.isArray(proxyConfig)) {
    proxyConfig = [proxyConfig];
  }
  const proxyServer = process.env.http_proxy || process.env.HTTP_PROXY;
  let agent = null;

  if (proxyServer) {
    console.log(`Using corporate proxy server: ${proxyServer}`);
    agent = new HttpsProxyAgent(proxyServer);
    proxyConfig.forEach(entry => {
      entry.agent = agent;
    });
  }

  return proxyConfig;
}

module.exports = setupForCorporateProxy(proxyConfig);
