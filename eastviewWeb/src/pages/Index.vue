<template>
  <q-page class="flex flex-center">
    <div class="q-page-container">
    <div class="row">
    <h2>{{$t('Welcome')}}</h2>
    </div>
    <div class="row">
      <div class="col">
        <img
          alt="Eastview logo"
          src="~assets/eastview.gif"
        >
      </div>
    </div>
    </div>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex'
}
</script>
