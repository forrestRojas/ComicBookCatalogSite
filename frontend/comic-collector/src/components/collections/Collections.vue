<template>
		<section>
				<comic-collection
						v-for="collection in comicCollections" 
						v-bind:key="collection.id"
						v-bind:collection="collection"
						v-bind:userName="userName"
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
		comicCollections: Array
	},
	data() {
		return {
			userName: ""
		}
	},
	methods: {
		created() {
			
		}
	}
}
</script>

<style>

</style>
