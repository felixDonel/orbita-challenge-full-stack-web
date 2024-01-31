<template>

    <v-app-bar
      color="primary"
      prominent>
      <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
  
      <v-toolbar-title>{{ title }}</v-toolbar-title>
    </v-app-bar>
  
    <v-navigation-drawer
      v-model="drawer"
      location="left"
      temporary
    >
      <v-list>
        <v-list-item
          v-for="items in items"
          :key="items.value"
          :to="items.value"
          items.value
        >
          <v-list-item-content>
            <v-list-item-title>{{ items.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </template>
  
  <script>
  export default {
    name: 'NavegationBarComponent',
    props: {
        title: String
    },
  data: () => ({
    drawer: false,
    group: null,
    items: [
      {
        title: 'Alunos',
        value: '/',
      },
    ],
  }),
  
  watch: {
    group () {
      this.drawer = false
    },
  },
  }
  </script>