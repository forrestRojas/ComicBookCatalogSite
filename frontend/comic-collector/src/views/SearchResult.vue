<template>
    <main id="search-result">
        <h2>Results</h2>
        <comic-summary 
            v-for="comic in comics" 
            v-bind:key="comic.id" 
            v-bind:comic="comic"
        ></comic-summary>        
    </main>
</template>

<script>
import ComicSummary from '@/components/comics/ComicSummary.vue';
export default {
    name: 'search-result',
    components: {
        ComicSummary,
    },
    data() {
        return {
            comics:[]
        }
    },
    created() {
        const { searchBy, searchQuery } = this.$route.params;
        fetch(`${process.env.VUE_APP_REMOTE_API}/search/${searchBy}/${searchQuery}`, {
        method: 'GET'
        })
        .then(response => response.json())
        .then(json => this.comics = json);
    },
    watch: {
        $route: function (to, from) {
            if( to !== from){
                let { searchBy, searchQuery } = this.$route.params;
                fetch(`${process.env.VUE_APP_REMOTE_API}/search/${searchBy}/${searchQuery}`, {
                method: 'GET'
                })
                .then(response => response.json())
                .then(json => this.comics = json);
            }
        }
    }
}
</script>

<style>
#search-result h2 {
    box-sizing: content-box;
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 0;
    padding: 8px 0;
    height: 85px;
}
</style>
    