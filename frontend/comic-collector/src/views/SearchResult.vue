<template>
    <form>
        <input type="text" v-model="search_issue" placeholder="search issue number"/><br>
        <button type="submit">Search</button>
        <!-- <button type="submit" @click.stop.prevent="submit()">Search</button> -->
    </form>
</template>

<script>
export default {
    data() {
        return {
            comics:[],
            search_issue: ''
        }
    },
    methods: {
        submit() {
            this.$router.push("/SearchResult?"+this.search_issue);
        }
    },
    computed: {
        filteredComics: function(){
            return this.comics.filter((comic) => {
                return comic.issueNumber.match(this.search_issue);
            })
        }
    }
}
</script>

<style>

</style>
    