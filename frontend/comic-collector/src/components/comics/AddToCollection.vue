<template>
  <aside>
    <button :form="formId">Add to Collecton</button>
    
    <dialog>
      <form :id="formId" v-on:submit.prevent="addToCollection">
        <select :form="formId" v-model="selected" >
            <option disabled value="">Please select one</option>
            <option 
              v-for="{id, title} in collections" 
              :key="id" 
              :value="title" 
            >
              {{ title }}
            </option>
        </select>

        <section>
          <button :form="formId" class="btn-cancel" value="Cancel">
            Cancel
          </button>

          <button :form="formId" type="submit" class="btn-add" value="Add to collection">
            Add to collection
          </button>
        </section>
      </form>
    </dialog>
  </aside>
</template>

<script>
import dialogPolyfill from 'dialog-polyfill';
import auth from '@/shared/auth.js';
//import isElementSupported from '@ryanmorr/is-element-supported';

export default {
// get user id
// get user collection

  props: {
    comicId: Number,
  },
  data() {
    return {
      collections: [],
      formId: `${this.comicId}-add-comic-form`,
      selected: '',
      userId: Number
    }
  },
  created() {
    const dialog = document.querySelector('dialog');
    dialogPolyfill.registerDialog(dialog);
    // Now dialog acts like a native <dialog>.
    dialog.showModal();
  },
  methods: {
    addToCollection() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/user/${auth.getUser().sub}`, {
          method: 'GET'
      })
      .then(response => response.json())
      .then(({ id }) => this.userId = id);

      fetch(`${process.env.VUE_APP_REMOTE_API}/collections`, {
        method: 'GET'
      })
      .then(response => response.json())
      .then(collections => this.collections = (() => collections.filter(collection => collection.userId === this.userId)));
    }
  }
}
</script>

<style>

</style>
