<template>
    <div>
        <slot></slot>
    </div>
</template>


<script>
    export default {
        props: {
            options: { type: Object }
        },
        data() {
            return {
                table: null
            }
        },
        mounted() {
            this.table = $(this.$el).find("table").dataTable(this.options || {});
            this.table.on('draw', function () {
                console.log("table-has-been-drawn");
            });
        }
    }
</script>