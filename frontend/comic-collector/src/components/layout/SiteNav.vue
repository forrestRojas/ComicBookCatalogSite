<template>
    <nav>
        <a href="/collections">Collections</a>
        <input type="text" v-model="search" placeholder="search comics"/>
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
    }
}
</script>

<style>
    a {
        text-decoration: none;
    }
</style>
