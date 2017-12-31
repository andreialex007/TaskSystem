<template>
    <footer class="footer">
        <div class="container-fluid">
            <span class="info pull-right">&#169; Task system {{ year }}</span>
        </div>
    </footer>
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
