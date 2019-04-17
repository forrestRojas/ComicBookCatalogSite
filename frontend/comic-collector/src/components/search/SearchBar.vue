<template>
  <form id="search-form" name="search-form" class="search-bar">
    <select form="search-form" type="number">
      <option value="byTitle">By Title</option>
      <option value="byPublisher">By Publisher</option>
    </select>
    <input form="search-form" type="text" v-model="search_title" placeholder="comic title"/>
    <input form="search-form" type="number" min="0" v-model="search_issue" placeholder="comic volume"/>
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
          id: Number
      }
  },
  methods: {
    async submit() {
      let response = await
      fetch(`${process.env.VUE_APP_REMOTE_API}/search/${this.search_title}/${this.search_issue}`,{
        method: 'GET'
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
