<template>
  <footer class="footer" :class="{ [`footer-${type}`]: type }" :data-background-color="backgroundColor">

    <p>This website made by Group 2:</p>
    <p><strong>Nguyen Huu Men</strong></p>
    <p><strong>Nguyen Quoc Tai</strong></p>
    <p><strong>Truong Hoa Ky</strong></p>
    <p>Thanks to Vue Material Kit and all support from our friends from another group</p>

  </footer>
</template>
<script>
export default {

  data() {

  }
};
</script>
<style>
p {
  text-align: center;

}
</style>
