import Vue from 'vue'
import MainLayout from './components/layout/Main.vue'
import styles from './assets/font-awesome-4.7.0/css/font-awesome.css'

Vue.filter("toLowercase", x => x.toLowerCase());

new Vue({
  el: '#app',
  render: function (h) {
    return h(MainLayout);
  }
});


export const eventBus = new Vue();
eventBus.$on("notify",
  function () {
    console.log("notify event");
  });
