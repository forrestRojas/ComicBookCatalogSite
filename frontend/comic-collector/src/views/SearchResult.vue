<template>
    <main id="search-result">
        
    </main>
</template>

<script>
export default {
    data() {
        return {
            comics:[],
            search_issue: ''
        }
    },
    // methods: {
    //     submit() {
    //         this.$router.push("/SearchResult?"+this.search_issue);
    //     }
    // },
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
    