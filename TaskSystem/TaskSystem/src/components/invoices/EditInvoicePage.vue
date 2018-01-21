<template>
	<main-layout>
		<div class="col-lg-12">
			<h1 class="mt-5">
				<template v-if="!$route.params.id">
					Create
				</template>
				<template v-if="!!$route.params.id">
					<span class="badge badge-success">#{{$route.params.id}}</span>
					Edit
				</template>
				Invoice
			</h1>
			<hr />
			<form>
				<div v-show="errors.length > 0" class="alert alert-danger" role="alert">
					<strong>Errors found!</strong>
					<ul>
						<li v-for="item in errors">
							{{ item.errorMessage }}
						</li>
					</ul>
				</div>
				<div class="row form-group">
					<div class="col-md-4 task-col">
						<label>Task</label>
						<input type="text" class="form-control" v-model="invoice.taskName" readonly placeholder="Task Name">
						<span class="badge badge-primary task-id-badge">#{{ invoice.taskId }}</span>
					</div>
					<div class="col-md-4">
						<label>Customer Name</label>
						<input type="text" class="form-control" v-model="invoice.customerName" readonly placeholder="Customer Name">
					</div>
					<div class="col-md-4">
						<label>Customer User Name</label>
						<input type="text" class="form-control" v-model="invoice.customerUserName" readonly placeholder="Customer User Name">
					</div>
				</div>
				<div class="row form-group">
					<div class="col-md-12">
						<label>Remarks</label>
						<br />
						<textarea v-model="invoice.remarks" placeholder="put your remarks here (required)" class="form-control"></textarea>
					</div>
				</div>

				<br />
				<div class="text-center">
					<span v-on:click="save" class="btn btn-primary">
						<i class="fa fa-floppy-o" aria-hidden="true"></i>
						Save
					</span>
					<span v-on:click="back" class="btn btn-danger">
						<i class="fa fa-reply" aria-hidden="true"></i>
						Back
					</span>
				</div>
			</form>

			<template v-if="!!$route.params.id">

				<h3>Invoice Elements</h3>

				<a href="javascript:;" v-on:click="createElement()" class="btn btn-primary">Add Element</a>
				<br />
				<br />

				<table v-show="invoice.invoiceElements.length > 0" class="table table-bordered table-striped invoice-elements-table">
					<thead class="thead-dark">
						<tr>
							<th>Id</th>
							<th>Category</th>
							<th>Description</th>
							<th>Cost</th>
							<th>Qty</th>
							<th>Total</th>
							<th>Actions</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="item in invoice.invoiceElements">
							<th>{{ item.id }}</th>
							<th>{{ item.categoryName }}</th>
							<th>{{ item.description }}</th>
							<th>{{ item.cost }}</th>
							<th>{{ item.qty }}</th>
							<th>{{ item.qty * item.cost }}$</th>
							<th>
								<a title="edit" v-on:click="editItem(item)" class="edit btn btn-primary btn-xs" href="javascript:;">
									<i class="fa fa-edit"></i>
									Edit
								</a>
								<a title="edit" v-on:click="deleteItem(item.id)" class="edit btn btn-danger btn-xs" href="javascript:;">
									<i class="fa fa-times"></i>
									Delete
								</a>
							</th>
						</tr>
					</tbody>
				</table>
				
			</template>

		</div>

		<invoice-element-modal ref="editInvoiceElementModal"
							   v-bind:categories="invoice.categories"
							   v-bind:commonElements="invoice.commonInvoiceElementItems"
							   v-bind:data="currentElement"></invoice-element-modal>
		<confirm-modal ref="confirmModal" title="Are you sure?">
			<span>Are you really want to delete this item?</span>
		</confirm-modal>

	</main-layout>
</template>


<script>
	import mainLayout from "./../layout/MainLayout.vue"
	import uiBase from "./../common/UiBase.vue"
	import confirmModal from "./../common/ConfirmModal.vue"
	import invoiceElementModal from "./../invoices/EditInvoiceElementModal.vue"

	export default {
		extends: uiBase,
		components: {
			mainLayout,
			confirmModal,
			invoiceElementModal
		},
		data() {
			return {
				invoice: {
					commonInvoiceElementItems: [],
					invoiceElements: []
				},
				currentElement: {}
			};
		},
		mounted() {
			this.load();
			this.checkSaved();
		},
		methods: {
			createElement() {
				this.currentElement = { id: 0 };
				this.$refs.editInvoiceElementModal.show(this.elementSaved);
			},
			editItem(x) {
				this.currentElement = x;
				this.$refs.editInvoiceElementModal.show(this.elementSaved);
			},
			elementSaved(x) {
				let index = this.invoice.invoiceElements.map(x => x.id).findIndex(u => u == x.id);
				if (index === -1) {
					this.invoice.invoiceElements.push(x);
				} else {
					this.invoice.invoiceElements[index] = x;
				}
				this.$forceUpdate();
			},
			load() {
				if (!this.$route.params.id) {
					this.$http
						.post(`/invoices/task${this.$route.params.taskId}/add`)
						.then(this.loadCompleted);
				} else {
					this.$http
						.post(`/invoices/${this.$route.params.id}`)
						.then(this.loadCompleted);
				}
			},
			loadCompleted(result) {
				this.invoice = result.body;
			},
			back() {
				this.$router.go(-1);
			},
			deleteItem(id) {
				let component = this;
				this.$refs.confirmModal.show(function () {
					console.log("delete");
					component.blockUI({
						message: 'Deletion, please wait...'
					});
					component.$http.post("/invoices/deleteitem/" + id)
						.then(function () {
							component.deleteItemCompleted(id)
						})
				});
			},
			deleteItemCompleted(id) {
				this.invoice.invoiceElements = this.invoice.invoiceElements.filter(x => x.id != id);
				this.unblockUI();
				toastr.info("Item deleted", "Success");
			},
			save() {
				var component = this;
				this.$http.post("/invoices/save", this.invoice)
					.then(function (response) {
						Cookies.set('isSaved', `Invoice #${response.body.id} Saved`, { expires: 7, path: '/' });
						this.$router.push({ path: `/invoices/${response.body.id}` });
						this.checkSaved();
					})
					.catch(x => {
						component.errors = x.body.errors
					});
			}
		}
	}
</script>