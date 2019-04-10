<template>
	<article class="collection" v-on:click="GotoCollection">
		<picture class="collection-img">
			<source v-bind:srcset="collection.image" />
			<img v-bind:src="collection.image" alt="Collection image." />
		</picture>
		<h4 class="collection-name">{{collection.title}}</h4>
		<p class="username">{{collection.userName}}</p>
		<p class="collection-description">{{collection.description}}</p>
	</article>
</template>

<script>
export default {
	name: 'comic-collection',
	props: {
			collection: Object,
	},
	methods: {
		GotoCollection() {
			this.$router.push({ name: 'collections', params: { id: this.collection.id } });
		}
	}
}
</script>

<style>

</style>
