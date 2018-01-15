//vue
import Vue from 'vue'
import VueRouter from "vue-router"
import VueResource from "vue-resource"
import Vuex from 'vuex'

Vue.use(VueRouter);
Vue.use(VueResource);
Vue.use(Vuex);

import googleAutocomplete from "./components/common/GoogleAutocomplete.vue"
import summerNote from "./components/common/SummerNote.vue"
import select2 from "./components/common/Select2.vue"
Vue.component('google-autocomplete', googleAutocomplete);
Vue.component('summer-note', summerNote);
Vue.component('select2', select2);


//styles
import fontAwesome from './assets/font-awesome-4.7.0/css/font-awesome.css'
import lineAwesome from './assets/line-awesome/css/line-awesome.css'
import bootstrap from './assets/bootstrap/scss/bootstrap.scss'

import select2Css from './assets/styles/select2.css'

import bootstrap4Datatables from './assets/styles/datatables.css'
import toastr from './assets/styles/toastr.scss'
import summernote from './assets/summernote/summernote-bs4.css'
import commonStyles from './assets/styles/common.scss'

//scripts
window.$ = require('jquery');
window.toastr = require('toastr');
window.toastr.options.closeButton = true;
window.toastr.options.positionClass = "toast-top-center";
window.toastr.options.closeHtml = '<button><i class="icon-off"></i></button>';

var dt = require('datatables.net-bs4');
window.$.DataTable = dt;
window.$.select2 = require('select2');

// $.fn.select2.defaults.set("ajax--type", "post");
// $.fn.select2.defaults.set("ajax--dataType", "json");
$.fn.select2.defaults.set("placeholder", "Please select item");
$.fn.select2.defaults.set("width", "100%");
$.fn.select2.defaults.set("allowClear", true);

// $.fn.select2.defaults.set("theme", "bootstrap4");

window.moment = require('./assets/scripts/moment');
window.blockUI = require('block-ui');
require('./assets/bootstrap/js/bootstrap.bundle');

window.CodeMirror = false;
require('./assets/summernote/summernote-bs4');
window.Cookies = require('./assets/scripts/js.cookie');

import router from "./router"
import { storeModel } from "./store/app.main.js"
import main from './components/Main.vue'

window.isUserLoggedIn = function () {
  return !!localStorage.authToken;
}

window.appRoot = "http://localhost:12395/api";
Vue.http.options.responseType = "json";

$.ajaxSetup({
  headers: {
    Accept: 'application/json'
  },
  beforeSend: function (xhr, settings) {
    xhr.setRequestHeader("Authorization", `Bearer ${localStorage.authToken}`);
    if (settings.dataType === 'binary') {
      settings.xhr().responseType = 'arraybuffer';
      settings.processData = false;
    }
  }
});

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


