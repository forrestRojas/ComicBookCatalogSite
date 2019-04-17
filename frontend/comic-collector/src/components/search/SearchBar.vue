<template>
  <form id="search-form" name="search-form" class="search-bar">
    <select  v-model="searchBy" form="search-form">
      <option value="1" selected>By Title</option>
      <option value="2">By Publisher</option>
      <option value="3">By Date</option>
    </select>
    
    <input v-if="searchBy == 1" form="search-form" type="text" v-model="search_title" placeholder="comic title"/>
    <input v-if="searchBy == 1" form="search-form" type="number" min="0" v-model="search_issue" placeholder="comic issue"/>

    <input v-if="searchBy == 2" form="search-form" type="text" v-model="search_publisher" placeholder="publisher name"/>
    
    <input v-if="searchBy == 3" form="search-form" type="text" v-model="search_date.start" placeholder="start date"/>
    <input v-if="searchBy == 3" form="search-form" type="text" v-model="search_date.end" placeholder="end date"/>
    
    <button form="search-form" type="submit" @click.stop.prevent="submit()">Search</button>
  </form>
</template>

<script>
export default {
  name: 'search-bar',
  data() {
      return {
          comics:[],
          search_title: '',
          search_issue: '',
          search_publisher: '',
          search_date: {
            start: Date,
            end: Date
          },
          searchBy: '1',
          id: Number
      }
  },
  methods: {
    getSerachUrl(){
      let searchUrl = '';
      switch(Number(this.searchBy)) {
        case 1:
          searchUrl = `search/${this.search_title}/${this.search_issue}`;
          break;
        case 2:
          searchUrl = `comic/publisher/${this.search_publisher}`;
          break;
        case 3:
            let { start, end } = this.search_date;
            searchUrl = `comic/date/${start}${end}`;
          break;
      }
      return searchUrl;
    },

    async submit() {
      let searchUrl = await this.getSerachUrl();
      let response = await
      fetch(`${process.env.VUE_APP_REMOTE_API}/${searchUrl}`,{
        method: 'GET',
          headers:{
          'Access-Control-Request-Headers': 'content-type',
          'Content-Type': 'application/json'
  }
        })
        let json = await response.json();
        this.id = json.id;
        this.searchResult();
      },
      searchResult(){
        this.$router.push({ path: `/comic/${this.id}`});
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
      display: grid;
      margin: 0 8px;
      gap: 8px;

      /* move to media query */
      /* grid-template-columns: 175px 85px; */
      grid-template-columns: auto 85px;
      grid-template-areas: 
        ". search"
        ". search"
        ". search";
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
      height: 85px;
      grid-area: search;
      padding: 0;
    }
</style>
