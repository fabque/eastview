<template>
  <q-page padding>
    <!-- content -->

    <div class="q-pa-md">
      <div class="row justify-end">
        <div class="col">
          <h4>{{ $t('Citizens') }}</h4>
        </div>
        <div class="col">
          <div class="row justify-end q-mt-xl q-gutter-sm">

            <q-btn unelevated color="blue-7" class="" :label="$t('Add Citizen')" type="button" @click="$router.push('/addCitizen')" />
          </div>
        </div>
      </div>

      <q-table
        :data="citizens"
        :columns="columnsI18n"
        row-key="id"
        class=""
        :filter="filter"
        :filter-method="customFilter"
        virtual-scroll
        :pagination.sync="pagination"
        :rows-per-page-options="[]"
        :no-data-label="$t('no.data')"
      >

        <template v-slot:top-right>
<!--          <q-select
            clearable
            dense
            outlined
            color="blue"
            v-model="standTypeIdFilter"
            :options="standTypes"
            option-value="id"
            option-label="id"
            :label="$t('standType')"
            emit-value
            map-options
            class="select-stand-type"
          ></q-select>-->

          <q-input
            outlined
            dense
            debounce="300"
            v-model="textFilter"
            :placeholder="$t('Filter')"
          >
            <template v-slot:append>
              <q-icon name="search" />
            </template>
          </q-input>
        </template>
        <template v-slot:body-cell-action="props">
          <q-td :props="props">

            <q-btn dense round flat color="grey" @click="editRow(props)" icon="edit">
              <q-tooltip>
                {{ $t('Edit')}}
              </q-tooltip>
            </q-btn>
            <q-btn dense round flat color="grey" @click="deleteRow(props)" icon="delete">
              <q-tooltip>
                {{ $t('Delete')}}
              </q-tooltip>
            </q-btn>
          </q-td>
        </template>
      </q-table>
    </div>

  </q-page>
</template>

<script>
import { apiInstance } from 'boot/api'

export default {
  data: () => ({
    textFilter: '',
    citizens: [],
    pagination: {
      rowsPerPage: 0
    }
  }),
  computed: {
    columnsI18n () {
      const columns = [
        {
          name: 'firstname',
          required: true,
          label: this.$t('Firstname'),
          align: 'left',
          field: 'firstName',
          sortable: true
        },
        {
          name: 'email',
          required: true,
          label: this.$t('Lastname'),
          align: 'left',
          field: 'lastName',
          sortable: true
        },
        {
          name: 'address',
          required: true,
          label: this.$t('Address'),
          align: 'left',
          field: 'address',
          sortable: true
        },
        {
          name: 'job',
          required: true,
          label: this.$t('Job'),
          align: 'center',
          field: 'job',
          sortable: true
        },
        {
          name: 'action',
          align: 'center',
          label: this.$t('Actions'),
          field: 'action'
        }
      ]
      return columns
    },
    filter () {
      return {
        search: this.textFilter
      }
    }
  },
  methods: {
    /* getDays () {
      apiInstance.getDays().then((
        days) => {
        this.days = days
      })
    }, */
    getCitizens () {
      apiInstance.getCitizens().then((data) => {
        this.citizens = data
      })
    },
    editRow (props) {
      // const item = props.row
      // this.$router.push(`/editCitizen/${item.id}`)
      alert('Edit item ')
    },
    deleteRow (props) {
      // const item = props.row
      // do something
      this.$q.dialog({
        title: this.$i18n.tc('Are you sure to delete'),
        message: this.$i18n.tc(''),
        ok: {
          push: true,
          label: this.$i18n.tc('Cancel'),
          outline: true,
          color: 'grey'
        },
        cancel: {
          push: true,
          color: 'red',
          label: this.$i18n.tc('Delete')
        },
        persistent: true
      }).onOk(() => {
        // console.log('>>>> OK')
      }).onOk(() => {
        // console.log('>>>> second OK catcher')
      }).onCancel(() => {
        // console.log('>>>> Cancel')
        // todo call api
        this.$q.notify({
          timeout: 3000,
          message: this.$i18n.tc('Citizen deleted'),
          type: 'positive',
          icon: 'info',
          position: 'bottom'
        })
      }).onDismiss(() => {
        // console.log('I am triggered on both OK and Cancel')
      })
    },
    customFilter (rows, terms) {
      // rows contain the entire data
      // terms contains whatever you have as filter
      const lowerSearch = this.textFilter ? this.textFilter.toLowerCase() : ''
      const filteredRows = rows.filter(
        (row, i) => {
          let ans = false
          // Assume true in case there is no search
          let st = true
          // Gather toggle conditions
          // const c1 = (isEmpty(this.dayIdFilter)) || (!isEmpty(this.dayIdFilter) && this.dayIdFilter === row.day)

          // Gather search condition
          // If search term exists, convert to lower case and see which rows contain it
          if (lowerSearch !== '') {
            st = false
            // Get the values
            const s1Values = Object.values(row)
            // Convert to lowercase
            const s1Lower = s1Values.map(x => x.toString().toLowerCase())

            // for (let val = 0; val < s1Lower.length; val++) {
            if (s1Lower.includes(lowerSearch)) {
              st = true
              // break
            }
            // }
          }
          // assume row doesn't match
          ans = false
          // check if any of the conditions match
          if (st) {
            ans = true
          }
          return ans
        })
      return filteredRows
    }
  },
  created () {
    this.getCitizens()
    this.getDays()
  }
}
</script>
