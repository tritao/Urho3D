#CPPSHARP_DIR = CppSharp
CPPSHARP_DIR = /Users/joao/Dev/CppSharp/build/gmake/lib/Debug_x32

CPPSHARP_REFS = -r:$(CPPSHARP_DIR)/CppSharp.dll \
	-r:$(CPPSHARP_DIR)/CppSharp.AST.dll \
	-r:$(CPPSHARP_DIR)/CppSharp.Parser.CSharp.dll \
	-r:$(CPPSHARP_DIR)/CppSharp.Generator.dll

NEWTONSOFT_DIR = Newtonsoft.Json.6.0.8/lib/net45
DEPS_REFS = 

SRC_ROOT = ../..

TARGET_NAME = UrhoBindingsGen
TARGET_EXE = $(TARGET_NAME).exe

.stamp-clone:
	@if [ ! -d $(CPPSHARP_DIR) ]; then \
		git clone git@github.com:tritao/CppSharpBinaries.git $(CPPSHARP_DIR); \
		touch $@; \
	fi

.stamp-deps:
	#nuget install Newtonsoft.Json
	touch $@;

$(TARGET_EXE): .stamp-clone .stamp-deps UrhoBindingsGen.cs 
	mcs UrhoBindingsGen.cs $(CPPSHARP_REFS) $(DEPS_REFS)

gen: $(TARGET_EXE)
	MONO_PATH=$(CPPSHARP_DIR) mono $(TARGET_EXE)

gen-proj:
	$(CPPSHARP_DIR)/premake5 vs2012

clean:
	rm $(TARGET_EXE)

all: $(TARGET_EXE)