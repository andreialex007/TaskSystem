<template>
  <div id="app">
    <app-header></app-header>
    <img src="../../assets/logo.png">
    <h1>Hello world</h1>
    <app-server-status>
      <h2 slot="title"><strong >Title</strong></h2>
    </app-server-status>
    <button class="btn btn-danger" v-on:click="notifyEventBus">Notify</button>
    <span class="btn btn-primary" v-on:click="switchComponent">SwitchComponents</span>
    <strong >{{ testString | toUppercase | toLowercase }}</strong>
    <keep-alive><component :is="selectedComponent"></component></keep-alive>
    <app-footer></app-footer>
  </div>
</template>


<script>
  import appServerStatus from '../server/ServerStatus.vue'
  import appHeader from '../layout/Header.vue'
  import appFooter from '../layout/Footer.vue'
  import { eventBus } from "../../main"
  import first from "../layout/First.vue"
  import second from "../layout/Second.vue"

  export default {
    components: {
      appHeader,
      appFooter,
      appServerStatus,
      first,
      second
    },
    data() {
      return {
        selectedComponent: "first",
        testString: "myteststring"
      };
    },
    methods: {
      notifyEventBus() {
        eventBus.$emit("notify");
      },
      switchComponent() {
        this.selectedComponent = this.selectedComponent == "first" ? "second" : "first";
      }
    },
    filters: {
      toUppercase: (x) => x.toUpperCase()
    }
  };
</script>
<style lang="scss">
  .inner-content {
    border: 1px solid black;
    margin: 10px !important;
  }
</style>
