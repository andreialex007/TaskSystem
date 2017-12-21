import Vue from 'vue'
import MainLayout from './components/layout/Main.vue'
import fontAwesome from './assets/font-awesome-4.7.0/css/font-awesome.css'
import bootstrap from './assets/bootstrap/css/bootstrap.css'
import commonStyles from './assets/style.scss'


window.$ = window.jQuery = require('./assets/scripts/jquery-3.2.1.min');
window.moment = require('./assets/scripts/moment');
require('./assets/bootstrap/js/bootstrap.bundle');


Vue.filter("toLowercase", x => x.toLowerCase());

new Vue({
  el: '#app',
  render: function (h) {
    return h(MainLayout);
  }
});


export const eventBus = new Vue();
