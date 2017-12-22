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
