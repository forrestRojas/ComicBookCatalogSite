<template>
    <form>
        <input type="text" v-model="search" placeholder="search comics"/><br>
        <button type="submit" @click.stop.prevent="submit()">Submit</button>
    </form>
    
</template>

<script>
export default {
    data() {
        return {
            comics:[],
            search: ''
        }
    },
    methods: {
        submit() {
            this.$router.push("/SearchResult?"+this.search);
        }
    },
    computed: {
        filteredComics: function(){
            return this.comics.filter((comic) => {
                return comic.match(this.search);
            })
        }
    }
}
</script>

<style>

</style>
    