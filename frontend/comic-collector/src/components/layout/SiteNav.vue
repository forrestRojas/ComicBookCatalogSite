<template>
    <nav>
<<<<<<< HEAD
        <form>
            <input type="text" v-model="search_title" placeholder="comic title"/>
            <input type="text" v-model="search_issue" placeholder="comic issue"/>
            <!-- <div v-for="comic in comics" class="single-comic">
+                <h2>{{comic.title}}</h2>
+                <p>{{comic.anotherproperty}}</p> -->
           <!-- </div> -->
            <button type="submit" @click.stop.prevent="submit()">Search</button>
        </form>
=======
        <search-bar></search-bar>
>>>>>>> 337040b09cde58f61195c4eb9b5d91f396b4c3cd
        <ul>
            <li><a href="/collections">Collections</a></li> 
            <li><a href="/create/" v-if="auth = true">Create Collection</a></li>
            <li><a href="/statistics/" v-if="auth = true">Comic Statistics</a></li>
        </ul>
    </nav>
</template>

<script>
import SearchBar from '@/components/search/SearchBar.vue';

export default {
    name: 'site-nav',
    components: {
        SearchBar
    }
    // data() {
    //     return {
    //         comics:[],
    //         search_title: '',
    //         search_issue: ''
    //     }
    // },
    // methods: {
    //     submit() {
    //         fetch(`${process.env.VUE_APP_REMOTE_API}/search/${search_title}/${search_issue}`,{
    //             method: 'GET'
    //         })
    //         .then (response => response.json())
    //         .then(({ id }) => this.id=id);
    //         this.$router.push({ path: `/comic/${found.id}`});
    //     }
    // },
    // created() {
    //     // this.$http.get(/*api goes here*/).then(function(data){
    //     //     this.comics = data.body.slice(0, /*total number of api comics*/);
    //     // })
    // },
    // computed: {
    //     filteredComics: function(){
    //         return this.comics.filter((comic) => {
    //             return comic.title.match(this.search_title, this.search_issue);
    //         })
    //     }
    // }
}
</script>

<style>
    nav {
        padding-top: .5em;  
    }

    nav ul {
        list-style: none;
        padding: 0px;
    }

    nav li {
        padding-bottom: 10px;
    }
</style>
    
