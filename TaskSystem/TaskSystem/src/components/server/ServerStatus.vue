<template>
  <div>
    <div><p>Server status {{ status }}</p></div>
    <button class="btn btn-primary" v-on:click="changeStatus">
    <i class="fa fa-plane" ></i>
    Change status</button>
    <hr />
    <div class="slot-wrapper" >
      <slot name="title"></slot>
      <hr />
      <slot name="content">Default content</slot>
    </div>
  </div>
</template>
<script>
  export default {
    data: function () {
      return { status: 'critical' };
    },
    methods: {
      changeStatus: function () {
        this.status = "Normal";
      }
    }
  }
</script>
<style scoped lang="scss">
  button {
    background-color: lightblue;
  }

  .slot-wrapper{
    padding: 5px;
    margin: 5px;
    border: 1px solid red;
  }

</style>
