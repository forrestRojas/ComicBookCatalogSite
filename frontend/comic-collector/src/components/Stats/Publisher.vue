<template>
    <article class="publishers">
    <h2>Publisher</h2>
    <ol >
    <li v-for="publisher in publishers" 
		v-bind:key="publisher.name"
		v-bind:publishers="publishers"
    >{{publisher.name}}: {{publisher.value}}</li>
    </ol>
    </article>
</template>

<script>
export default {
name: "publisher",
data(){
    return {
        publishers: []
        
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/publisher`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.publishers = json});
}
}
</script>

<style>
.publishers {
    width: 250px; 
}
</style>
