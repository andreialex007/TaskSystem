<template>
    <div class="form-control"></div>
</template>


<script>
    export default {
        props: {
            options: {
                type: Object, default: () => ({
                    toolbar: [
                        ['style', ['style']],
                        ['font', ['bold', 'italic', 'underline', 'superscript', 'subscript', 'strikethrough', 'clear']],
                        ['fontname', ['fontname']],
                        ['fontsize', ['fontsize']],
                        ['color', ['color']],
                        ['para', ['ul', 'ol', 'paragraph']],
                        ['height', ['height']],
                        ['table', ['table']],
                        ['insert', ['link', 'picture', 'video', 'hr']],
                        ['view', ['codeview']]
                    ]
                })
            },
            value: { type: String }
        },
        watch: {
            value() {
                if ($(this.$el).summernote("code") != this.value)
                    $(this.$el).summernote("code", this.value);
            }
        },
        data() {
            return {
                editor: null
            }
        },
        mounted() {
            let component = this;
            this.options.callbacks = {
                onBlur: function (contents, $editable) {
                    component.$emit("update:value", $(this).summernote("code"));
                }
            };
            $(this.$el).summernote(this.options);
            $(this.$el).summernote("code", this.value);
        },
        beforeDestroy() {
            $(this.$el).summernote("destroy");
        }
    }
</script>