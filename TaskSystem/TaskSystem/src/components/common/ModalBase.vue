<script>

    import pageBase from "./../common/UiBase.vue"

    export default {
        extends: pageBase,
        props: {
            title: { type: String }
        },
        data() {
            return {
                visible: false,
                okFunc: null,
                cancelFunc: null
            }
        },
        mounted() {

        },
        methods: {
            hide() {
                console.log("hide");
                this.visible = false;
            },
            show(okFunc, cancelFunc) {
                this.okFunc = okFunc;
                this.cancelFunc = cancelFunc;
                this.visible = true;
            },
        }
    }
</script>