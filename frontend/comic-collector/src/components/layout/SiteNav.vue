<template>
    <nav>
        <a href="/collections">Collections</a>
        <form>
            <input type="text" v-model="search" placeholder="search comics"/><br>
            <button type="submit" @click.stop.prevent="submit()">Submit</button>
        </form>
        
    </nav>
</template>

<script>
export default {
    name: 'site-nav',
    data() {
        return {
            comics:[],
            search: ''
        }
    },
    methods: {
        submit() {
            this.$router.push("/SearchResult"+this.search);
        }
    },
    created() {
            //   logic to retrieve all comics  
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
    a {
        text-decoration: none;
    }
</style>
