<template>
    <nav>
        <a href="/collections">Collections</a>
        <form>
            <input type="text" v-model="search_title" placeholder="comic title"/><br>
            <input type="text" v-model="volume_search" placeholder="comic volume"/><br>
            <!-- <div v-for="comic in comics" class="single-comic">
+                <h2>{{comic.title}}</h2>
+                <p>{{comic.anotherproperty}}</p> -->
           <!-- </div> -->
        </form>
            <button type="submit" @click.stop.prevent="submit()">Submit</button>
       
        
    </nav>
</template>

<script>
export default {
    name: 'site-nav',
    data() {
        return {
            comics:[],
            search_title: '',
            volume_search: ''
        }
    },
    methods: {
        submit() {
            this.$router.push("/SearchResult?"+this.search);
        }
    },
    created() {
        this.$http.get(/*api goes here*/).then(function(data){
            this.comics = data.body.slice(0, /*total number of api comics*/);
        })
    },
    computed: {
        filteredComics: function(){
            return this.comics.filter((comic) => {
                return comic.title.match(this.search_title);
                return comic.volume.match(this.volume_search);
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
