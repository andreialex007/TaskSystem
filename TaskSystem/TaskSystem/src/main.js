//vue
import Vue from 'vue'
import VueRouter from "vue-router"
import VueResource from "vue-resource"

Vue.use(VueRouter);
Vue.use(VueResource);

//styles
import fontAwesome from './assets/font-awesome-4.7.0/css/font-awesome.css'
import bootstrap from './assets/bootstrap/css/bootstrap.css'
import commonStyles from './assets/styles/common.scss'

//scripts
window.$ = window.jQuery = require('./assets/scripts/jquery-3.2.1.min');
window.moment = require('./assets/scripts/moment');
require('./assets/bootstrap/js/bootstrap.bundle');

import router from "./router"
import main from './components/Main.vue'

localStorage.isUserLoggedIn = localStorage.isUserLoggedIn || false;

window.appRoot = "http://localhost:12395/api";
//Vue.http.options.root = 'http://localhost:12395/api';
//Vue.http.headers.common['Content-Type'] = "application/json";

new Vue({
  el: '#app',
  router,
  render: function (h) {
    return h(main);
  }
});

export const eventBus = new Vue();
