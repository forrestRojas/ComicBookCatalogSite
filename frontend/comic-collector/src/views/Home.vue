<template>
<main id="home">
<article>
    <recently-updated></recently-updated>
    <top-user></top-user>
    <largest-collections></largest-collections>
    <most-popular></most-popular>

</article>
</main>
</template>

<script>

import TopUser from '@/components/Stats/TopUser.vue';
import LargestCollections from '@/components/Stats/LargestCollections.vue';
import MostPopular from '@/components/Stats/MostPopular.vue';
import RecentlyUpdated from '@/components/Stats/RecentlyUpdated.vue'


export default {
components:{
TopUser,
LargestCollections,
MostPopular,
RecentlyUpdated
}

}
</script>

<style>

</style>