<template>
  <aside v-if="this.comicId">
    <button :form="formId" v-on:click="displayDialog">Add to Collecton</button>
    
    <dialog :id="dialogId">
      <p v-if="result">{{ resultMessage }}</p>
      <form :id="formId" v-on:submit.prevent="AddToCollection()">
        <select :form="formId" v-model="selected" >
            <option disabled value="">Please select one</option>
            <option 
              v-for="{id, title} in collections" 
              :key="title" 
              :value="id" 
            >
              {{ title }}
            </option>
        </select>

        <section>
          <button :form="formId" class="btn-cancel" value="Cancel" v-on:click="closeDialog">
            Cancel
          </button>
          <button :form="formId" type="submit" class="btn-add" value="Add to collection" v-on:click="AddToCollection">
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
      dialogId: `${this.comicId}-add-comic-dialog`,
      selected: Number,
      userId: Number,
      resultMessage: ''
    }
  },
  created() {
    this.getUserId();
  },
  watch: {
    comicId(newID, oldID) {
      if( newID === undefined || newID === oldID) {
          return;
      } else {
        this.formId = this.comicId;
        this.dialogId = this.comicId;
      }
    }
  },
  methods: {
    // Dialog methods
    displayDialog() {
      const dialog = document.getElementById(this.dialogId);
      this.polyfillDialog();
      this.GetAvaibleCollections();
      
      dialog.showModal();
    },
    closeDialog() {
      const dialog = document.getElementById(this.dialogId);
      this.polyfillDialog();
      dialog.close();
    },

    // fetch methods
    getUserId() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/user/${auth.getUser().sub}`,{
        method: 'GET'
      })
      .then(response => response.json())
      .then(({ id }) => this.userId=id);
    },
    GetAvaibleCollections() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/collections/${this.userId}/${this.comicId}`, {
        method: 'GET'
      })
      .then(response => response.json())
      .then(collections => this.collections = collections);
    },
    AddToCollection() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/save/${this.selected}/${this.comicId}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: "Bearer " + auth.getToken()
        },
      }).then(response => {
        if(response.ok) {
          this.success();
        } else {
          this.error();
        }
      }); 
    },

    success() {
      const p = document.querySelector(`#${this.dialogId} > p`);
      //if()
      p.classList.add('success');
    },
    
    error() {

    },

    polyfillDialog() { 
      const dialogTag = document.querySelector('dialog');
      dialogPolyfill.registerDialog(dialogTag);
    },
  }
}
</script>

<style>
dialog {
  top: 25%;
  transition: all 1s;
  background: var(--isabelline);
  border-color: var(--black-olive);
  padding: 3em;
}

dialog[open] {
  top: 50%;
}

dialog::backdrop {
    background: rgba(32, 11, 7, 0.5);
}

</style>