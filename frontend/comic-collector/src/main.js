import Vue from 'vue'
import App from './App.vue'
import router from './router'

Vue.config.productionTip = false;

require('./assets/reset.css');
require('./assets/imageslogo-01.svg');
require('./assets/default-avatar.jpg');
require('./assets/tenor.gif');
require('./assets/thanos.gif');
new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
