<template>
    <input type="text" v-bind:value.sync="address" v-on:keyup="keyup" class="form-control" placeholder="Please select address" />
</template>


<script>
    export default {
        props: {
            options: { type: Object },
            address: { type: String }
        },
        data() {
            return {
                autocomplete: null
            }
        },
        mounted() {
            let component = this;
            this.autocomplete = new google.maps.places.Autocomplete(this.$el);
            this.autocomplete.addListener('place_changed', function () {
                component.$emit("update:address", $(component.$el).val());
            });
        },
        computed: {
            
        },
        methods: {
            keyup() {
                this.$emit("update:address", $(this.$el).val());
            }
        }
    }
</script>