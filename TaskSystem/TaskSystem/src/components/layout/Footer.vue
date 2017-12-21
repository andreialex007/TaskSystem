<template>
    <div class="app-footer">
        <span class="info">&#169; Task system {{ year }}</span>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                year: moment().format("YYYY")
            }
        }
    }
</script>

<style scoped lang="scss">
    .app-footer {
        background-color: #e5e4e4;
        padding: 10px;
        font-size: 14px;
        padding-top: 5px;
        padding-bottom: 5px;
        .info

    {
        float: right;
    }

    }
</style>
