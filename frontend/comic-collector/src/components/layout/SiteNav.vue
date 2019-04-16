<template>
    <nav>
        <form>
            <input type="text" v-model="search_title" placeholder="comic title"/>
            <input type="text" v-model="search_issue" placeholder="comic issue"/>
            <!-- <div v-for="comic in comics" class="single-comic">
+                <h2>{{comic.title}}</h2>
+                <p>{{comic.anotherproperty}}</p> -->
           <!-- </div> -->
            <button type="submit" @click.stop.prevent="submit()">Search</button>
        </form>
        <ul>
            <li><a href="/collections">Collections</a></li> 
            <li><a href="/create/" v-if="auth = true">Create Collection</a></li>
            <li><a href="/statistics/" v-if="auth = true">Comic Statistics</a></li>
        </ul>
            
    </nav>
</template>

<script>
export default {
    name: 'site-nav',
    data() {
        return {
            comics:[],
            search_title: '',
            search_issue: ''
        }
    },
    methods: {
        submit() {
            fetch(`${process.env.VUE_APP_REMOTE_API}/search/${search_title}/${search_issue}`,{
                method: 'GET'
            })
            .then (response => response.json())
            .then(({ id }) => this.id=id);
            this.$router.push({ path: `/comic/${found.id}`});
        }
    },
    created() {
        // this.$http.get(/*api goes here*/).then(function(data){
        //     this.comics = data.body.slice(0, /*total number of api comics*/);
        // })
    },
    computed: {
        filteredComics: function(){
            return this.comics.filter((comic) => {
                return comic.title.match(this.search_title, this.search_issue);
            })
        }
    }
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

    nav form {
        grid-template-areas: ". search" " . search ";
        display:inline-grid;
        gap: 8px;
        grid-template-columns: 175px 85px;
        
        /* grid-auto-flow: column; */
    }

    nav button {
    background-color: #4CAF50;
    border: none;
    color: white;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    width: 85px;
    grid-area: search;
    padding: 0;
    }
</style>
    
