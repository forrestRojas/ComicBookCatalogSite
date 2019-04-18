<template>
    <article class="totalcomics">
    <h2>Total Comics</h2>
    <p>{{totalcomics}}</p>
    </article>
</template>

<script>
export default {
name: "total-comics",
data(){
    return {
        totalcomics: Number
    }
},
created(){
    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/totalcomics`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.totalcomics = json});
}
}
</script>

<style>
.totalcomics {
    width: 250px;
}
</style>
