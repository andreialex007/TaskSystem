//vue
import Vue from 'vue'
import VueRouter from "vue-router"
import VueResource from "vue-resource"
import Vuex from 'vuex'

Vue.use(VueRouter);
Vue.use(VueResource);
Vue.use(Vuex);

//styles
import fontAwesome from './assets/font-awesome-4.7.0/css/font-awesome.css'
import bootstrap from './assets/bootstrap/css/bootstrap.css'
import commonStyles from './assets/styles/common.scss'
import bootstrap4Datatables from './assets/styles/datatables.css'
import toastr from './assets/styles/toastr.scss'

//scripts
window.$ = require('jquery');
window.toastr = require('toastr');
window.toastr.options.closeButton = true;
window.toastr.options.positionClass = "toast-top-center";
window.toastr.options.closeHtml = '<button><i class="icon-off"></i></button>';

var dt = require('datatables.net-bs4');
window.$.DataTable = dt;

window.moment = require('./assets/scripts/moment');
require('./assets/bootstrap/js/bootstrap.bundle');
window.Cookies = require('./assets/scripts/js.cookie');

import router from "./router"
import { storeModel } from "./store/app.main.js"
import main from './components/Main.vue'

window.isUserLoggedIn = function () {
  return !!localStorage.authToken;
}

window.appRoot = "http://localhost:12395/api";
Vue.http.options.responseType = "json";

Vue.http.interceptors.push((request, next) => {
  request.url = window.appRoot + request.url;

  request.headers.set('Authorization', `Bearer ${localStorage.authToken}`);
  request.headers.set('Accept', 'application/json');

  next((response) => {
    if (response.status == 401) {
      localStorage.authToken = "";
      router.go('/login');
    }
  });
});

let store = new Vuex.Store(storeModel);

new Vue({
  el: '#app',
  router,
  store,
  render: function (h) {
    return h(main);
  }
});


