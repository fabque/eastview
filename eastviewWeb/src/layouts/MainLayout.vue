<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>
          Eastview App
        </q-toolbar-title>

        <div></div>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      content-class="bg-grey-1"
    >
      <q-list>
        <q-item-label
          header
          class="text-grey-8"
        >
          Eastview App
        </q-item-label>
        <EssentialLink
          v-for="link in essentialLinks"
          :key="link.title"
          v-bind="link"
        />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import EssentialLink from 'components/EssentialLink.vue'
import { i18n } from 'boot/i18n'

const linksData = [
  {
    title: i18n.tc('Welcome'),
    caption: i18n.tc('Welcome'),
    icon: 'dashboard',
    link: '#/home'
  },
  {
    title: i18n.tc('Citizens'),
    caption: i18n.tc('Citizens'),
    icon: 'group',
    link: '#/citizens'
  },
  {
    title: i18n.tc('Tasks'),
    caption: i18n.tc('Tasks'),
    icon: 'list',
    link: '#/tasks'
  },
  {
    title: i18n.tc('Miranda'),
    caption: i18n.tc('Miranda'),
    icon: 'map',
    link: '/miranda'
  }

]

export default {
  name: 'MainLayout',
  components: { EssentialLink },
  data () {
    return {
      leftDrawerOpen: false,
      essentialLinks: linksData
    }
  }
}
</script>
