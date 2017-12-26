<script>
    export default {
        props: {
            title: { type: String }
        },
        data() {
            return {
                visible: true
            }
        },
        mounted() {

        },
        methods: {
            hide() {
                this.visible = false;
            },
            show() {
                this.visible = true;
            },
        }
    }
</script>