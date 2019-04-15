<template>
    <nav>
        <form>
            <input type="text" v-model="search_title" placeholder="comic title"/><br>
            <input type="text" v-model="search_issue" placeholder="comic issue"/><br>
            <!-- <div v-for="comic in comics" class="single-comic">
+                <h2>{{comic.title}}</h2>
+                <p>{{comic.anotherproperty}}</p> -->
           <!-- </div> -->
            <button type="submit" @click.stop.prevent="submit()">Search</button><br>
        </form>
            <a href="/collections">Collections</a><br>
            <a href="/create/" v-if="auth = true">Create Collection</a>
    </nav>
</template>

<script>
export default {
    name: 'site-nav',
    data() {
        return {
            comics:[],
            search_title: '',
            search_issue: '',
            foundId: Number
        }
    },
    methods: {
        async submit() {
            //     fetch(`${process.env.VUE_APP_REMOTE_API}/search/${this.search_title}/${this.search_issue}`,{
            //         method: 'GET'
            // })
            // .then (response => response.json())
            // .then( ({ json }) => this.foundId = json.id)

            let response = await
            fetch(`${process.env.VUE_APP_REMOTE_API}/search/${this.search_title}/${this.search_issue}`,{
                    method: 'GET'
            });
            let json = await response.json();
            this.foundId = json.id
            this.searchResults();
        },
        searchResults(){
            this.$router.push({ path: `/comic/${this.foundId}`})
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
    a {
        text-decoration: none;
    }
</style>
