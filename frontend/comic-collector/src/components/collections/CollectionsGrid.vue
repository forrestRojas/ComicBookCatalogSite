<template>
	<section class="collections-grid">
		<comic-collection
				v-for="collection in comicCollections" 
				v-bind:key="collection.id"
				v-bind:collection="collection"
		></comic-collection>
	</section>
</template>

<script>
import ComicCollection from '@/components/collections/ComicCollection.vue';

export default {
	name: 'collections',
	components: {
		ComicCollection
	},
	props: {
		comicCollections: Array,
	}
}
</script>

<style scoped>
.collections-grid {
	display: grid;
	grid-auto-rows: auto-fill, 1fr;
}
</style>
