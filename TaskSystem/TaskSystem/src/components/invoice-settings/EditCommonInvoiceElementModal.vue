<template>
	<div class="edit-invoice-element-category-modal common-modal">
		<div v-show="visible" class="modal-overlay"></div>
		<div v-show="visible" class="modal">
			<div class="modal-dialog" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">
							<span v-show="model.id > 0">Edit</span>
							<span v-show="!model.id">Create</span>
							invoice common element <span v-show="!!model.id" class="badge badge-danger">#{{ model.id }}</span>
						</h5>
						<button v-on:click="cancel()" type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body">
						<div v-show="errors.length > 0" class="alert alert-danger" role="alert">
							<strong>Errors found!</strong>
							<ul>
								<li v-for="item in errors">
									{{ item.errorMessage }}
								</li>
							</ul>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Name</label>
								<input type="text" class="form-control" v-model="model.description" placeholder="Description (required)" value="">
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Cost</label>
								<input type="number" class="form-control" v-model="model.cost" placeholder="Cost (required)" value="">
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Category (required)</label>
								<select v-model="model.invoiceElementCategoryId" class="form-control" >
									<template v-for="category in categories" >
										<option v-bind:value="category.id" >{{ category.name }}</option>
									</template>
								</select>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<a v-on:click="ok()" href="javascript:;" class="btn btn-primary">Save</a>
						<a v-on:click="cancel()" href="javascript:;" class="btn btn-secondary" data-dismiss="modal">Cancel</a>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
	import modalBase from "./../common/ModalBase.vue"

	export default {
		extends: modalBase,
		props: {
			data: { type: Object },
			categories: { type: Array }
		},
		watch: {
			visible(newVal) {
				if (newVal == false)
					this.model = {};
				if (newVal == true)
					this.model = { ...this.data };
			}
		},
		data: () => ({
			model: {}
		}),
		methods: {
			ok() {
				let component = this;
				component.blockUI({
					message: 'Saving, please wait...'
				});
				this.$http.post(`/invoicesettings/SaveCommonInvoiceElement`,
					this.model)
					.then((x) => {
						component.unblockUI();
						toastr.info("saved", "Success");
						component.okFunc(x.body);
						component.hide();
					}).catch(x => {
						component.unblockUI();
						component.errors = x.body.errors;
					});
			},
			cancel() {
				if (this.cancelFunc)
					this.cancelFunc();
				this.hide();
			}
		}
	}
</script>