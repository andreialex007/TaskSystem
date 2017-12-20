import Vue from 'vue'
import MainLayout from './components/layout/Main.vue'
import styles from './assets/font-awesome-4.7.0/css/font-awesome.css'

window.$ = window.jQuery = require('./assets/scripts/jquery-3.2.1.min');


Vue.filter("toLowercase", x => x.toLowerCase());

new Vue({
  el: '#app',
  render: function (h) {
    return h(MainLayout);
  }
});


export const eventBus = new Vue();
