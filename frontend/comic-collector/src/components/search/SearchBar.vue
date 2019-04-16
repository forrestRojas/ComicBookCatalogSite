<template>
  <form class="search-bar">
    <input type="text" v-model="search_title" placeholder="comic title"/>
    <input type="text" v-model="search_issue" placeholder="comic volume"/>
    <button type="submit" @click.stop.prevent="submit()">Search</button>
  </form>
</template>

<script>
export default {
  name: 'search-bar',
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
   .search-bar {
      grid-template-areas: ". search" " . search ";
      display:inline-grid;
      gap: 8px;
      grid-template-columns: 175px 85px;
      
      /* grid-auto-flow: column; */
    }

    .search-bar button {
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
